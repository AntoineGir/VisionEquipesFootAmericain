using System;

namespace VisionEquipesFootAmericain.viewModel
{
    internal class RelayCommand : Icommand
    {
        private Action p1;
        private Func<bool> p2;

        public RelayCommand(Action p1, Func<bool> p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
    }
}