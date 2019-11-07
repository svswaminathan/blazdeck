using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace blazdeck
{
    /// <summary>
    /// Proxy for receiving key press events from JavaScript.
    /// </summary>
    public static class InteropKeyPress
    {
        /// <summary>
        /// Fires when a KeyUp message is received from JavaScript.
        /// </summary>
        public static event EventHandler<ConsoleKey> KeyUp;

          
        /// <summary>
        /// Called by JavaScript when a Key Up event fires.
        /// </summary>
        /// <param name="e"><see cref="ConsoleKey"/> number.</param>
        /// <returns>
        /// JavaScript Promise with the converted <see cref="ConsoleKey"/> value or <see langword="null"/> if
        /// no equivalent is found.
        /// </returns>
        [JSInvokable]
        public static Task<bool> JsKeyUp(int e)
        {
            var found = false;
            var consoleKey = default(ConsoleKey);

            try
            {
                consoleKey = (ConsoleKey)e;
                found = true;
            }
            catch
            {
                Console.WriteLine($"Cound not find {nameof(ConsoleKey)} for JS key value {e})");
            }

            if (found)
                KeyUp?.Invoke(null, consoleKey);

            return Task.FromResult(found);
        }
    }
}