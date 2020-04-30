using System;
using Xunit;

namespace BearToday.Tests
{
    public abstract class SpecificationFor<T>
    {
        protected SpecificationFor()
        {
            Subject = Given();
            When();
        }

        public T Subject { get; set; }
        public abstract T Given();
        public abstract void When();

    }
}
