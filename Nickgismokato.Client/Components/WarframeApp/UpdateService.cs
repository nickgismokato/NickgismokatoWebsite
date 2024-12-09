using System.Timers;

namespace Nickgismokato.Client.Components.WarframeApp;

public class UpdateService : IAsyncDisposable{
    private readonly System.Timers.Timer _timer;
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    public UpdateService(){
        // Configure the timer for a 4-hour interval (in milliseconds)
        _timer = new System.Timers.Timer(4 * 60 * 60 * 1000); 
        _timer.Elapsed += async (sender, args) => await UpdateAsync();
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    public async Task UpdateAsync(){
        await _semaphore.WaitAsync();
        try{
            await HTTPRequest.GetJSONFile(true);
        }finally{
            _semaphore.Release();
        }
    }

    public ValueTask DisposeAsync(){
        _timer?.Stop();
        _timer?.Dispose();
        _semaphore?.Dispose();
        return ValueTask.CompletedTask;
    }
}
