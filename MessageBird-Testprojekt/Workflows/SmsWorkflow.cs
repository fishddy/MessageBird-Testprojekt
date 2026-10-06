using MessageBird_Testprojekt.Models;

namespace MessageBird_Testprojekt.Workflows
{
    public class SmsWorkflow
    {
        public string CreateMessage(Customer customer, MessagePreset messagePreset)
        {
            return messagePreset.Text
                .Replace("{Name}", customer.Name)
                .Replace("{Creditnumber}", customer.CreditNumber)
                .Replace("{amount}", customer.Amount.ToString())
                .Replace("{dueDate}", customer.DueDate);
        }
    }
}
