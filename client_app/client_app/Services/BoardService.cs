using client_app.Models;
using client_app.Models.Responses;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace client_app.Services;

public class BoardService(IHttpClientService httpClientService, IUserService userService)
{
    private readonly IHttpClientService _httpClientService = httpClientService;
    private readonly IUserService _userService = userService;

    public ObservableCollection<Board> Boards { get; set; } = new ObservableCollection<Board>();

    public async Task LoadBoardsFromApi()
    {
        Boards.Clear();

        var response = await _httpClientService.GetAsync($"board/load?id={_userService.User.Id}");
        Debug.WriteLine(response);
        if (response.IsSuccessStatusCode)
        {
            var boards = await response.Content.ReadFromJsonAsync<List<Board>>();

            foreach ( var board in boards )
            {
                Boards.Add(board);
            }
        }
    }
}
