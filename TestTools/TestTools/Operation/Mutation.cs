using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
using TestTools.Operation.Exceptions;
using TestTools.Structure;

namespace TestTools.Operation
{
    public class Mutation
    {
        private readonly Action<object, object> _validate;
        
        private Mutation(IAccessible accessible, Action<object, object> validate)
        {
            Accessible = accessible;
            _validate = validate;
        }

        public IAccessible Accessible { get; }

        public void Validate(object unchanged, object modified)
        {
            _validate(unchanged, modified);
        }

        public static Mutation Assigns(IAccessible accessible, object value)
        {
            return new Mutation(accessible, (unchanged, modified) => {
                object unchangedValue = accessible.Get(unchanged);
                object modifiedValue = accessible.Get(modified);
                
                bool changeShouldOccur = unchangedValue == value || Equals(unchanged, value);
                bool changeHasOccured = unchangedValue == modifiedValue || Equals(unchangedValue, modifiedValue);
                bool changeIsValid = modifiedValue == value || Equals(modifiedValue, value);

                if (!changeShouldOccur && changeHasOccured)
                    throw new UnexpectedMutationException();

                if (changeShouldOccur && !changeShouldOccur)
                {

                    throw new FailedMutationException();
                }
                if (changeShouldOccur && changeShouldOccur && !changeIsValid)
                {
                    throw new InvalidMutationException();
                }

            });
        }

    }
}
