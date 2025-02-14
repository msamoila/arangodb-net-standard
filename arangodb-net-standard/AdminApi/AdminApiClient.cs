﻿using System.Net;
using System.Threading.Tasks;
using ArangoDBNetStandard.Serialization;
using ArangoDBNetStandard.Transport;
using ArangoDBNetStandard.AdminApi.Models;
using System.Threading;

namespace ArangoDBNetStandard.AdminApi
{
    /// <summary>
    /// A client for interacting with ArangoDB Admin API,
    /// implementing <see cref="IAdminApiClient"/>.
    /// </summary>
    public class AdminApiClient : ApiClientBase, IAdminApiClient
    {
        /// <summary>
        /// The transport client used to communicate with the ArangoDB host.
        /// </summary>
        protected IApiClientTransport _client;

        /// <summary>
        /// The root path of the API.
        /// </summary>
        protected readonly string _adminApiPath = "_admin";

        /// <summary>
        /// Creates an instance of <see cref="AdminApiClient"/>
        /// using the provided transport layer and the default JSON serialization.
        /// </summary>
        /// <param name="client">Transport client that the API client will use to communicate with ArangoDB</param>
        public AdminApiClient(IApiClientTransport client)
            : base(new JsonNetApiClientSerialization())
        {
            _client = client;
        }

        /// <summary>
        /// Creates an instance of <see cref="AdminApiClient"/>
        /// using the provided transport and serialization layers.
        /// </summary>
        /// <param name="client">Transport client that the API client will use to communicate with ArangoDB.</param>
        /// <param name="serializer">Serializer to be used.</param>
        public AdminApiClient(IApiClientTransport client, IApiClientSerialization serializer)
            : base(serializer)
        {
            _client = client;
        }

        /// <summary>
        /// Retrieves log messages from the server.
        /// GET /_admin/log/entries
        /// Works on ArangoDB 3.8 or later.
        /// </summary>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <param name="query">Query string parameters</param>
        /// <returns></returns>
        /// <remarks>
        /// For further information see 
        /// https://www.arangodb.com/docs/stable/http/administration-and-monitoring.html#read-global-logs-from-the-server
        /// </remarks>
        public virtual async Task<GetLogsResponse> GetLogsAsync(GetLogsQuery query = null, CancellationToken token = default)
        {
            string uri = $"{_adminApiPath}/log/entries";
            if (query != null)
            {
                uri += '?' + query.ToQueryString();
            }
            using (var response = await _client.GetAsync(uri, null, token).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    return DeserializeJsonFromStream<GetLogsResponse>(stream);
                }
                throw await GetApiErrorException(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Reloads the routing table.
        /// POST /_admin/routing/reload
        /// </summary>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        /// <remarks>
        /// For further information see 
        /// https://www.arangodb.com/docs/stable/http/administration-and-monitoring.html#reloads-the-routing-information
        /// </remarks>
        public virtual async Task<bool> PostReloadRoutingInfoAsync(CancellationToken token = default)
        {
            string uri = $"{_adminApiPath}/routing/reload";
            var body = new byte[] { };
            using (var response = await _client.PostAsync(uri, body, null, token).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                throw await GetApiErrorException(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Retrieves the internal id of the server.
        /// The method will fail if the server is not running in cluster mode.
        /// GET /_admin/server/id
        /// </summary>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        /// <remarks>
        /// For further information see 
        /// https://www.arangodb.com/docs/stable/http/administration-and-monitoring.html#return-id-of-a-server-in-a-cluster
        /// </remarks>
        public virtual async Task<GetServerIdResponse> GetServerIdAsync(CancellationToken token = default)
        {
            string uri = $"{_adminApiPath}/server/id";
            using (var response = await _client.GetAsync(uri, null, token).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    return DeserializeJsonFromStream<GetServerIdResponse>(stream);
                }
                throw await GetApiErrorException(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Retrieves the role of the server in a cluster.
        /// GET /_admin/server/role
        /// </summary>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        /// <remarks>
        /// For further information see
        /// https://www.arangodb.com/docs/stable/http/administration-and-monitoring.html#return-the-role-of-a-server-in-a-cluster
        /// </remarks>
        public virtual async Task<GetServerRoleResponse> GetServerRoleAsync(CancellationToken token = default)
        {
            string uri = $"{_adminApiPath}/server/role";
            using (var response = await _client.GetAsync(uri, null, token).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    return DeserializeJsonFromStream<GetServerRoleResponse>(stream);
                }
                throw await GetApiErrorException(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Retrieves the server database engine type.
        /// GET /_api/engine
        /// </summary>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        /// <remarks>
        /// For further information see 
        /// https://www.arangodb.com/docs/stable/http/miscellaneous-functions.html#return-server-database-engine-type
        /// </remarks>
        public virtual async Task<GetServerEngineTypeResponse> GetServerEngineTypeAsync(CancellationToken token = default)
        {
            string uri = "_api/engine";
            using (var response = await _client.GetAsync(uri, null, token).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    return DeserializeJsonFromStream<GetServerEngineTypeResponse>(stream);
                }
                throw await GetApiErrorException(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Retrieves the server version.
        /// GET /_api/version
        /// </summary>
        /// <param name="query">Query string parameters</param>
        /// <param name="token">A CancellationToken to observe while waiting for the task to complete or to cancel the task.</param>
        /// <returns></returns>
        /// <remarks>
        /// For further information see 
        /// https://www.arangodb.com/docs/stable/http/miscellaneous-functions.html#return-server-version
        /// </remarks>
        public virtual async Task<GetServerVersionResponse> GetServerVersionAsync(GetServerVersionQuery query = null, CancellationToken token = default)
        {
            string uri = "_api/version";
            if (query != null)
            {
                uri += '?' + query.ToQueryString();
            }
            using (var response = await _client.GetAsync(uri,null,token).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                    return DeserializeJsonFromStream<GetServerVersionResponse>(stream);
                }
                throw await GetApiErrorException(response).ConfigureAwait(false);
            }
        }
    }
}