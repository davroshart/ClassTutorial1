using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        private float _Width;
        private float _Height;
        private string _Type;

        [NonSerialized()]
        private static frmPhotograph _photoDialog;
        
        public override void EditDetails()
        {
            if (_photoDialog == null)
            {
                _photoDialog = new frmPhotograph();
            }
            _photoDialog.SetDetails(_Name, _Date, _Value, _Width, _Height, _Type);
            if (_photoDialog.ShowDialog() == DialogResult.OK)
            {
                _photoDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Width, ref _Height, ref _Type);
            }
        }
    }
}
