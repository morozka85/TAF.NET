using CoreAPI;
using ModelsAPI;
using RestSharp;
using Serilog;

namespace ServicesAPI
{
    public class PlayListService
    {
        private readonly ApiClient _apiClient;

        public PlayListService(string baseUrlApi, string token)
        {
            _apiClient = new ApiClient(baseUrlApi, token);
        }

        public PlaylistModel GetPlaylistById(string playlist_id)
        {
            Log.Information($"Trying to get playlist by ID: {playlist_id}");
            var response = _apiClient.SendRequest<PlaylistModel>($"playlists/{playlist_id}", Method.Get);
            if (!response.IsSuccessful)
            {
                throw new InvalidOperationException($"Failed to get playlist. Status code: {response.StatusCode}. Response: {response.Content}");
            }                
            return response.Data;
        }

        public PlaylistModel CreatePlaylist(PlaylistModel playlist, string userId)
        {
            Log.Information($"Attempting to create a new playlist for user: {userId}");
            var response = _apiClient.SendRequest<PlaylistModel>($"users/{userId}/playlists", Method.Post, playlist);
            if (!response.IsSuccessful)
            {
                throw new InvalidOperationException($"Failed to create playlist. Status code: {response.StatusCode}. Response: {response.Content}");
            }
            Log.Information($"Created Playlist ID: {response.Data.Id}");
            return response.Data;
        }

        public RestResponse<PlaylistModel> UpdatePlaylist(PlaylistModel updatedPlaylist, string playlistId)
        {
            Log.Information($"Update playlist by ID: {playlistId}");
            var response = _apiClient.SendRequest<PlaylistModel>($"playlists/{playlistId}", Method.Put, updatedPlaylist);
            if (!response.IsSuccessful)
            {
                throw new InvalidOperationException($"Failed to update playlist. Status code: {response.StatusCode}. Response: {response.Content}");
            }
            Log.Information($"Updated Playlist ID: {updatedPlaylist.Id} , name:{updatedPlaylist.Name}, description: {updatedPlaylist.Description}");
            return response;
        }
    }
}
