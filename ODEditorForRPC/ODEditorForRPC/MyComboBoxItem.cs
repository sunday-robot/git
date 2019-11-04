using System;

namespace ODEditorForRpc {
    public class MyComboBoxItem {
        public Object Value;
        public string Name;

        public MyComboBoxItem(Object v, string n) {
            this.Value = v;
            this.Name = n;
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
