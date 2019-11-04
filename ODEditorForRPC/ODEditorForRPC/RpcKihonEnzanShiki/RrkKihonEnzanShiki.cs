using System.Collections;

namespace RpcKihonEnzanShiki {
    public class RpcKihonEnzanShiki {
        public int No;
        public Expression Expression;

        public RpcKihonEnzanShiki(int no, string expression) {
            this.No = no;
            this.Expression = Parser.Parse(expression);
        }

        public override string ToString() {
            return string.Format("{0,2}. {1}", this.No, this.Expression.ToString());
        }

        public double Evaluate(double a, double b, double c) {
            return this.Expression.Evaluate(a, b, c);
        }

        public Hashtable GetVariables() {
            var h = new Hashtable();
            this.Expression.GetVariables(ref h);
            return h;
        }
    }
}
