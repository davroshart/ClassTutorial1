using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsSculpture : clsWork
    {
        private float _Weight;
        private string _Material;

        [NonSerialized()]
        private static frmSculpture _sculptDialog;

        public override void EditDetails()
        {
            if (_sculptDialog == null)
            {
                _sculptDialog = new frmSculpture();
            }
            _sculptDialog.SetDetails(_Name, _Date, _Value, _Weight, _Material);
            if (_sculptDialog.ShowDialog() == DialogResult.OK)
            {
                _sculptDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Weight, ref _Material);
            }
        }
    }
}
