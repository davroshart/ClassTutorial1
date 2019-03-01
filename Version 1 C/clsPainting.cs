using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsPainting : clsWork
    {
        private float _Width;
        private float _Height;
        private string _Type;

        [NonSerialized()]
        private static frmPainting _paintDialog;

        public override void EditDetails()
        {
            if (_paintDialog == null)
            {
                _paintDialog = new frmPainting();
            }
            _paintDialog.SetDetails(_Name, _Date, _Value, _Width, _Height, _Type);
            if(_paintDialog.ShowDialog() == DialogResult.OK)
            {
               _paintDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Width, ref _Height, ref _Type);
            }
        }
    }
}
