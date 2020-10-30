//-----------------------------------------------------------------------
// <copyright file="SottApi.cs" company="LoginRadius">
//     Created by LoginRadius Development Team
//     Copyright 2019 LoginRadius Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using LoginRadiusSDK.V2.Common;
using LoginRadiusSDK.V2.Util;
using LoginRadiusSDK.V2.Models.ResponseModels;
using System.Threading.Tasks;

namespace LoginRadiusSDK.V2.Api.Account
{
    public class SottApi : LoginRadiusResource
    {
        /// <summary>
        /// This API allows you to generate SOTT with a given expiration time.
        /// </summary>
        /// <param name="timeDifference">The time difference you would like to pass, If you not pass difference then the default value is 10 minutes</param>
        /// <returns>Sott data For Registration</returns>
        /// 18.28

        public ApiResponse<SottResponseData> GenerateSott(int? timeDifference = null)
        {
            var request = ConfigureSottRequest(timeDifference);
            return ExecuteRequest<SottResponseData>(request);
        }

#if !NET_40
        /// <summary>
        /// This API allows you to generate SOTT with a given expiration time.
        /// </summary>
        /// <param name="timeDifference">The time difference you would like to pass, If you not pass difference then the default value is 10 minutes</param>
        /// <returns>Sott data For Registration</returns>
        /// 18.28

        public Task<ApiResponse<SottResponseData>> GenerateSottAsync(int? timeDifference = null)
        {
            var request = ConfigureSottRequest(timeDifference);
            return ExecuteRequestAsync<SottResponseData>(request);
        }
#endif

        private static ApiRequest ConfigureSottRequest(int? timeDifference)
        {
            var queryParameters = new QueryParameters
            {
                { "apiKey", ConfigDictionary[LRConfigConstants.LoginRadiusApiKey] },
                { "apiSecret", ConfigDictionary[LRConfigConstants.LoginRadiusApiSecret] }
            };
            if (timeDifference != null)
            {
                queryParameters.Add("timeDifference", timeDifference.ToString());
            }

            var resourcePath = "identity/v2/manage/account/sott";

            return ConfigureRequest(HttpMethod.GET, resourcePath, queryParameters, null);
        }
    }
}