using System;
using System.Collections.Generic;

namespace AndrewD.RecordLabel.Validators
{
    public interface ICustomModelValidator<TModel>
    {
        List<KeyValuePair<string, string>> Validate(TModel model);
    }
}
