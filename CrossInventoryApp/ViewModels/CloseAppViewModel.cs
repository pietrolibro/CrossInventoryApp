using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace CrossInventoryApp.ViewModels
{
    public class CloseAppViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> CloseCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public CloseAppViewModel()
        {
            CloseCommand = ReactiveCommand.Create(() => { /* nothing to do here */ });
            CancelCommand = ReactiveCommand.Create(() => {/* nothing to do here */ });
        }
    }
}
