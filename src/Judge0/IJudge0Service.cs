using System;
using System.Collections;

namespace Judge0
{
    public interface IJudge0Service
    {
        IAuthenticationService AuthenticationService { get; }

        IAuthorizationService AuthorizationService { get; }

        ISubmissionsService SubmissionsService { get; }

        ILanguagesService LanguagesService { get; }

        IStatusesService StatusesService { get; }
    }

    //TODO: System and Configuration, Statistics, Health Check
}
