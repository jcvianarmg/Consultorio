using System;

namespace Consult.Core.Shared.ModelViews
{
    public class TelefoneView : ICloneable
    {
        public int Id { get; set; }
        public string Numero { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
