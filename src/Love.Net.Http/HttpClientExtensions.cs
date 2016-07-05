// Copyright (c) rigofunc and lotosbin. All rights reserved.

using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace System.Net.Http {
    /// <summary>
    /// Represents the extensions for <see cref="HttpClient"/>.
    /// </summary>
    public static class HttpClientExtensions {
        private static MediaTypeWithQualityHeaderValue _mime;

        static HttpClientExtensions() {
            _mime = new MediaTypeWithQualityHeaderValue("application/json");
        }

        /// <summary>
        /// Send a POST request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="client">The client.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="value">The value.</param>
        /// <returns>A <see cref="Task{TResult}"/> represents the post operation.</returns>
        public async static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T value) {
            client.DefaultRequestHeaders.Accept.Add(_mime);

            return await client.PostAsync(requestUri, value.ToHttpContent());
        }

        /// <summary>
        /// Send a POST request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="client">The client.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="value">The value.</param>
        /// <returns>A <see cref="Task{TResult}"/> represents the post operation.</returns>
        public async static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value) {
            client.DefaultRequestHeaders.Accept.Add(_mime);

            return await client.PostAsync(requestUri, value.ToHttpContent());
        }

        /// <summary>
        /// Send a POST request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="client">The client.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="value">The value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{TResult}"/> represents the post operation.</returns>
        public async static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T value, CancellationToken cancellationToken) {
            client.DefaultRequestHeaders.Accept.Add(_mime);

            return await client.PostAsync(requestUri, value.ToHttpContent(), cancellationToken);
        }

        /// <summary>
        /// Send a POST request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="client">The client.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="value">The value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{TResult}"/> represents the post operation.</returns>
        public async static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value, CancellationToken cancellationToken) {
            client.DefaultRequestHeaders.Accept.Add(_mime);

            return await client.PostAsync(requestUri, value.ToHttpContent(), cancellationToken);
        }

        /// <summary>
        /// Send a PUT request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="client">The client.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="value">The value.</param>
        /// <returns>A <see cref="Task{TResult}"/> represents the put operation.</returns>
        public async static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, string requestUri, T value) {
            client.DefaultRequestHeaders.Accept.Add(_mime);

            return await client.PutAsync(requestUri, value.ToHttpContent());
        }

        /// <summary>
        /// Send a PUT request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="client">The client.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="value">The value.</param>
        /// <returns>A <see cref="Task{TResult}"/> represents the put operation.</returns>
        public async static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value) {
            client.DefaultRequestHeaders.Accept.Add(_mime);

            return await client.PutAsync(requestUri, value.ToHttpContent());
        }

        /// <summary>
        /// Send a PUT request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="client">The client.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="value">The value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{TResult}"/> represents the put operation.</returns>
        public async static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, string requestUri, T value, CancellationToken cancellationToken) {
            client.DefaultRequestHeaders.Accept.Add(_mime);

            return await client.PutAsync(requestUri, value.ToHttpContent(), cancellationToken);
        }

        /// <summary>
        /// Send a PUT request to the specified Uri as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="client">The client.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="value">The value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task{TResult}"/> represents the put operation.</returns>
        public async static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient client, Uri requestUri, T value, CancellationToken cancellationToken) {
            client.DefaultRequestHeaders.Accept.Add(_mime);

            return await client.PutAsync(requestUri, value.ToHttpContent(), cancellationToken);
        }

        internal static HttpContent ToHttpContent<T>(this T value) => new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");

        /// <summary>
        /// Sets authorization header with the specified scheme and token.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="scheme">The scheme.</param>
        /// <param name="token">The token.</param>
        public static void SetToken(this HttpClient client, string scheme, string token) {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);
        }

        /// <summary>
        /// Sets bearer authorization header with the specified token.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="token">The token.</param>
        public static void SetBearerToken(this HttpClient client, string token) {
            client.SetToken("Bearer", token);
        }
    }
}