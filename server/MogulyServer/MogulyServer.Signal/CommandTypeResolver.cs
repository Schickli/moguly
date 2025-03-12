using MediatR;
using MogulyServer.Signal.Feature;

namespace MogulyServer.Signal
{
    public class CommandTypeResolver
    {
        private readonly Lazy<Dictionary<string, Type>> _commandMap = new(CreateCommandMap);


        private static Dictionary<string, Type> CreateCommandMap()
        {
            var type = typeof(IGameCommand);

            var commandTypes = type.Assembly.GetTypes()
                .Where(t => type.IsAssignableFrom(t) && !t.IsInterface);

            return commandTypes.ToDictionary(t => t.Name);
        }

        public Type? GetCommandType(string commandName)
        {
            _commandMap.Value.TryGetValue(commandName, out var type);
            return type;
        }
    }

}
