using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace securing_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /*  
            Securing an ASP.Net Core Web API involves multiple layers of protection to ensure the data
            and services are safeguard against threats.

            1. USE HTTPS -
                    - Always Use HTTPS to encrypt data in transit. This prevents man-in-the-middle attacks
                        and ensures data privacy and integrity.
            
            2. Implement Authentication and Authorization -
                    - Authentication Verifies the identity of a user or service.
                    - Authorization determines what an authenticated user or services is allowed to do.
                        For Example, you can use JWT (JSON Web Token).

            3. Validate and Sanitize Input -
                    - Use Model Validation attributes like `[Required]`, `[StrigLength]` and `[Range]`.

            4. Use Anti-Forgery Tokens -
                    - Protected against Cross-Site Request Forgery (CSRF) attacks by using ant-forgery tokens.
                    - Apply `[ValidateAntiForgeryToken]` attribute to actions handling from data.
            
            5 . Rate Limiting and Throttling -
                    - Implement Rate Limiting and throttling to protect your API from abuse and denial of
                        service (DoS) attacks.

            6. Use Content Security Policy (CSP) -
                    - Implement CSP to prevent Cross-Site Scripting (XSS) and data injections attacks.

            7. Secure Sensitive Data - 
                    - Never Store sensitive data in plain text.
                    - Store sensitive configuration data (e.g., connection strings, API Keys) securely using
                        secrets management tools.

            8. Implement Logging and Monitoring -
                    - Log all authentication attempts, authorization failures, and unexpected errors.
                    - Use centralized logging solutions and monitoring tools to detect and respond to 
                        security incidents.

            9. Use Dependency Injection Securely -
                    - Register services with the appropriate lifetimes (Singleton, Scoped, Transient) to
                    avoid unintentional service sharing.

            10. Keep Software Updated -
                    - Regularly Update your application dependencies and .Net Core runtime to protect
                        against known vulnerabilities.
                    - Monitor and apply security patches.
        */
    }
}
