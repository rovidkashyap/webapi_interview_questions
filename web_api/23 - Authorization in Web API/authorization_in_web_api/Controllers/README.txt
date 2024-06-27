
Implementing authorization in an ASP.NET Core Web API involves a few steps. Here's a step-by-step guide:

STEP 1 - Install Required Packages -
		`Microsoft.AspNetCore.Authentication.JwtBearer`.

STEP 2 - Configure Authentication and Authorization in `Program.cs` -
		You need to configure the authentication and authorization middleware in `Program.cs` file.

STEP 3 - Secure your Controllers or Actions -
		Use the `[Authorize]` attribute to secure your controllers and actions.

STEP 4 - Generate and Validate JWT Tokens -
		You need to create endpoints to generate JWT tokens for users upon login and ensure that the
		token are validated for secure endpoints.