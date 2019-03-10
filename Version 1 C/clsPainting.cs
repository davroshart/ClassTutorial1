using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsPainting : clsWork
    {
        private float _Width;
        private float _Height;
        private string _Type;

       /* [NonSerialized()]
        private static frmPainting _paintDialog;*/

        public float Width { get => _Width; set => _Width = value; }
        public float Height { get => _Height; set => _Height = value; }
        public string Type { get => _Type; set => _Type = value; }

        public delegate void LoadPaintingFormDelegate(clsPainting prPainting);
        public static LoadPaintingFormDelegate LoadPaintingForm;

        public override void EditDetails()
        {
            /*if (_paintDialog == null)
                _paintDialog = frmPainting.Instance;
            _paintDialog.SetDetails(this);*/
            LoadPaintingForm(this);
        }

    }
}
