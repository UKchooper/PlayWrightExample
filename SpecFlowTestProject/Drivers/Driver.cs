using Microsoft.Playwright;

namespace SpecFlowTestProject.Drivers
{
    public class Driver : IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;

        public Driver() => _page = InitalizePlayWright();

        public IPage Page => _page.Result;

        private async Task<IPage> InitalizePlayWright()
        {
            var playWright = await Playwright.CreateAsync();

            _browser = await playWright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            return await _browser.NewPageAsync();
        }

        void IDisposable.Dispose() => _browser?.CloseAsync();
    }
}
