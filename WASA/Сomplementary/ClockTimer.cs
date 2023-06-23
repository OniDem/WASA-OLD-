using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WASA.Сomplementary
{
    public class ClockTimer
    {
        private readonly Action<DateTime> _action;
        private CancellationTokenSource _cts;

        public ClockTimer(Action<DateTime> action)
            => _action = action;

        public async void Start()
        {
            if (_cts != null)
                return;
            try
            {
                using (_cts = new CancellationTokenSource())
                {
                    while (true)
                    {
                        DateTime date = DateTime.Now;
                        _action(date);
                        await Task.Delay(1000 - date.Millisecond, _cts.Token);
                    }
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                Debug.Fail(ex.ToString());
            }
            _cts = null;
        }

        public void Stop()
            => _cts?.Cancel();
    }
}
