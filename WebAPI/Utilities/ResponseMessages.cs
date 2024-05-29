
using System.Text;

namespace WebAPI.Utilities
{
    public class ResponseMessages
    {
        public static StringBuilder EntityCreated()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Entity has been created!!!");

            return sb;

        }
    }
}
