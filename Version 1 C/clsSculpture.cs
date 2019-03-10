using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsSculpture : clsWork
    {
        private float _Weight;
        private string _Material;

        /*[NonSerialized()]
        private static frmSculpture _SculptDialog;*/

        public float Weight { get => _Weight; set => _Weight = value; }
        public string Material { get => _Material; set => _Material = value; }

        public delegate void LoadSculptureFormDelegate(clsSculpture prSculpture);
        public static LoadSculptureFormDelegate LoadSculptureForm;

        public override void EditDetails()
        {
            /*if (_SculptDialog == null)
                _SculptDialog = frmSculpture.Instance;
            _SculptDialog.SetDetails(this);*/
            LoadSculptureForm(this);
        }
    }
}
