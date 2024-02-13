using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.Common;

public abstract class BuildResult
{
    public abstract string Message { get; }

    internal class BuildSuccess : BuildResult
    {
        private readonly StringBuilder _messageBuilder;

        public BuildSuccess()
        {
            _messageBuilder = new StringBuilder();
        }

        public BuildSuccess(string message)
        {
            _messageBuilder = new StringBuilder(message);
        }

        public BuildSuccess(BuildSuccess successResult)
        {
            _messageBuilder = successResult._messageBuilder;
        }

        public override string Message =>
            "Assembly was successfully built." +
            (_messageBuilder.Length != 0
                ? "Some warnings during built were noticed: " + _messageBuilder
                : string.Empty);

        public void AddMessage(string message)
        {
            _messageBuilder.AppendJoin('\n', "- " + message);
        }
    }

    internal class BuildWithoutWarrantySuccess : BuildSuccess
    {
        public BuildWithoutWarrantySuccess()
        {
        }

        public BuildWithoutWarrantySuccess(string message)
            : base(message)
        {
        }

        public BuildWithoutWarrantySuccess(BuildSuccess successResult)
            : base(successResult)
        {
        }

        public override string Message =>
            base.Message + "\nNotification! Guarantee is not supported for this assembly.";
    }

    internal class BuildFail : BuildResult
    {
        private readonly string _message;

        public BuildFail(string message)
        {
            _message = message;
        }

        public override string Message =>
            "Build cannot be built successfully for reason '" + _message + "'.";
    }
}