namespace MauiRPNCalculator
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

		}
        protected override Window CreateWindow(IActivationState activationState) =>
            new Window(new AppShell())
            {
                Width = 300,
                Height = 600,
                X = 0,
                Y = 0
            };
    }
}
