using System;
using System.Collections;
using System.Net.Http;

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

    public class Judge0Service : IJudge0Service
    {
        public Judge0Service(HttpClient client)
        {
            Client = client;
            AuthenticationService = new AuthenticationService(client);
            AuthorizationService = new AuthorizationService(client);
            SubmissionsService = new SubmissionsService(client);
            LanguagesService = new LanguagesService(client);
            StatusesService = new StatusesService(client);
        }

        public HttpClient Client { get; }

        public IAuthenticationService AuthenticationService { get; }

        public IAuthorizationService AuthorizationService { get; }

        public ISubmissionsService SubmissionsService { get; }

        public ILanguagesService LanguagesService { get; }

        public IStatusesService StatusesService { get; }
    }
}
