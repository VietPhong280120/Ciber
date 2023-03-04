﻿namespace CiberWeb.Common
{
    public class SuccessResult<T>:Result<T>
    {
        public SuccessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
        }

        public SuccessResult()
        {
            IsSuccessed = true;
        }
    }
}
