using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hei.Admin.Core.EntityFrameworkExtend
{
    public class NewExpressionVisitor : ExpressionVisitor
    {
        public ParameterExpression _NewParameter { get; private set; }
        public NewExpressionVisitor(ParameterExpression param)
        {
            _NewParameter = param;
        }
        public Expression Replace(Expression exp)
        {
            return Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _NewParameter;
        }
    }
}
