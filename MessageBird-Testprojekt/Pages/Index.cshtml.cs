using MessageBird_Testprojekt.Abstractions;
using MessageBird_Testprojekt.Models;
using MessageBird_Testprojekt.Services;
using MessageBird_Testprojekt.Workflows;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessageBird_Testprojekt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CustomerService _customerService;
        private readonly MessagePresetService _messagePresetService;
        private readonly SmsWorkflow _smsWorkflow;
        private readonly ISmsService _smsService;

        public List<Customer> Customers { get; set; } = [];
        public List<MessagePreset> MessagePresets { get; set; } = [];

        public IndexModel(
        CustomerService customerService,
        MessagePresetService messagePresetService,
        SmsWorkflow smsWorkflow,
        ISmsService smsService)
        {
            _customerService = customerService;
            _messagePresetService = messagePresetService;
            _smsWorkflow = smsWorkflow;
            _smsService = smsService;
        }

        public async Task OnGetAsync()
        {
            Customers = await _customerService.GetAllAsync();
            MessagePresets = (await _messagePresetService.GetAll()).ToList();
        }

        public async Task<IActionResult> OnGetCustomerAsync(string id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            return new JsonResult(customer);
        }

        public async Task<IActionResult> OnGetMessagePresetAsync(string id)
        {
            var messagePreset = await _messagePresetService.GetByIdAsync(id);

            if (messagePreset == null)
                return NotFound();

            return new JsonResult(messagePreset);
        }

        public async Task<IActionResult> OnGetMessageAsync(string customerId, string messagePresetId)
        {
            var customer = await _customerService.GetByIdAsync(customerId);
            var messagePreset = await _messagePresetService.GetByIdAsync(messagePresetId);

            if (customer == null || messagePreset == null)
                return NotFound();

            var message = _smsWorkflow.CreateMessage(customer, messagePreset);

            return new JsonResult(new
            {
                message
            });
        }

        public async Task<IActionResult> OnPostSendSmsAsync(string customerId, string messagePresetId)
        {
            var customer = await _customerService.GetByIdAsync(customerId);
            var messagePreset = await _messagePresetService.GetByIdAsync(messagePresetId);

            if (customer == null)
                return BadRequest("Customer not found.");

            if (messagePreset == null)
                return BadRequest("Message preset not found.");

            var message = _smsWorkflow.CreateMessage(customer, messagePreset);
            var success = _smsService.SendSms(customer.PhoneNumber, message);

            if (!success)
            {
                return BadRequest(
                    "SMS could not be sent. Please check the MessageBird account and available credits.");
            }

            return new JsonResult(new
            {
                success = true
            });
        }
    }
}
