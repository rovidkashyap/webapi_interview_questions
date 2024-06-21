namespace principle_of_rest_architecture
{
    public class REST_Principles
    {
        // This DEMO is not demonstrate you the Code, but it will show you the REST Principles.
        // If any API will follow all these principles then it must say a RESTful Web API.

        // REST (Respresentational State Transfer) architecture define how web standards, such as HTTP,
        // should be used to create scalable and simple web services.

        // 1. Client-Server:
        //      - Separation of concerns: The Client and Server must have seperate entities.

        // 2. Stateless:
        //      - No Client Context Stored on the server: Each request from client to server must contains all
        //          the information needed to understand and process the request. The Server does not store
        //          any client session data between requests.

        // 3. Cacheable:
        //      - Improved Performance through Caching: Responses from server must be explicitly marked as 
        //          cacheable or non-cacheable. When appropriate, clients can cache responses to reduce the need
        //          for repeated requests.

        // 4. Uniform Interface:
        //      - Standardization Communication: A consistent and uniform interface between clients and server 
        //          simplifies and decouples the architecture. It has four constraints:
        //          1. Identification of Resources - Resources are identified using URIs (Uniform Resource Identifiers)
        //          2. Manipulation of resources through representations: Client interact with resource through
        //              their representations (e.g., JSON, XML).
        //          3. Self-Descriptive messages - Each message contains enough information to describe how to 
        //              process it.(e.g., metadata about the format).
        //          4. Hypermedia as the engine of application state (HATEOS) - Clients interact with the application
        //              application entirely through hypermedia provided dynamically by application servers.

        // 5. Layered System:
        //      - Modular Architecture - A layered system allows an architecture to be composed of hierarchical layers.
        //          Each layer has its role and can only interact with the adjacent layers.

        // 6. Code on Demand (Optional):
        //      - Extending Client Functionality - Servers can extending the functionality of a client by transferring
        //          executable code (e.g., JavaScript). This is Optional constraint and is not required for
        //          RESTful Architecture.
    }
}
