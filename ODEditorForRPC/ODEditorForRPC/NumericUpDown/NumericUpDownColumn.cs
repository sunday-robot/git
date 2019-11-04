using System;
using System.Windows.Forms;

namespace NumericUpDownColumn {
    public class NumericUpDownColumn : DataGridViewColumn {
        public NumericUpDownColumn()
            : base(new NumericUpDownCell()) {
        }

        public override DataGridViewCell CellTemplate {
            get {
                return base.CellTemplate;
            }
            set {
                // Ensure that the cell used for the template is a NumericUpDownCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(NumericUpDownCell))) {
                    throw new InvalidCastException("Must be a NumericUpDownCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
