using System;
using System.Collections.Generic;
using System.Linq;

namespace AndrewD.RecordLabel.Validators
{
    public class CustomModelValidator : ICustomModelValidator<ReleaseSlim>,
        ICustomModelValidator<Reference>
    {
        private Func<string, string, KeyValuePair<string, string>> GetEntry = 
            (key, value) => new KeyValuePair<string, string>(key, value);

        public List<KeyValuePair<string, string>> Validate(ReleaseSlim model)
        {
            var errors = new List<KeyValuePair<string, string>>();

            if (!typeof(PrintStatus).IsEnumDefined(model.PrintStatus))
            {
                errors.Add(GetEntry( nameof(model.PrintStatus), "Wrong Print Status value"));
            }
            // TODO: move these values to global scope
            if (model.Date < 1950 || model.Date > 2016)
            {
                errors.Add(GetEntry(nameof(model.Date), "Date must be between 1950 and 2016"));
            }

            var refErrors = model.References.SelectMany(x => Validate(x));
            errors.AddRange(refErrors);

            return errors;
        }

        public List<KeyValuePair<string, string>> Validate(Reference model)
        {
            var errors = new List<KeyValuePair<string, string>>();

            if (!typeof(ReferenceType).IsEnumDefined(model.Type))
            {
                errors.Add(GetEntry(nameof(model.Type), "Wrong Reference Type value"));
            }
            return errors;
        }
    }
}