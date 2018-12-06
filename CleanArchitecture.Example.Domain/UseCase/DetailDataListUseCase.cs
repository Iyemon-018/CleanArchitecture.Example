namespace CleanArchitecture.Example.Domain.UseCase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using CleanArchitecture.Example.Domain.Data;
    using CleanArchitecture.Example.Domain.UseCase.Request;
    using CleanArchitecture.Example.Domain.UseCase.Response;

    public sealed class DetailDataListUseCase : IDetailDataListUseCase
    {
        private static readonly int TaskCount = 10;

        public DetailDataListUseCaseResponse Handle(DetailDataListUseCaseRequest request)
        {
            var filmDirectors = new List<UserDetail>();
            request.ProgressPresenter.Initialize(TaskCount);
            request.ProgressPresenter.SetMessage("データを取得しています。しばらくお待ち下さい。");
            
            for (int i = 0; i < TaskCount; i++)
            {
                if (request.ProgressPresenter.IsCanceled)
                {
                    return new DetailDataListUseCaseResponse(ResponseResultType.Canceled, "ユーザーによってキャンセルされました。", null);
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));

                var filmDirector = FilmDirectorCache.Cache.TryGetValue(i, out var value) ? value : throw new InvalidOperationException(); 
                filmDirector.CreateDateTime = DateTime.Now;
                filmDirectors.Add(filmDirector);

                request.ProgressPresenter.UpdateValue(i + 1);
            }

            request.ProgressPresenter.SetMessage("完了までもうしばらくお待ち下さい。");
            Thread.Sleep(TimeSpan.FromSeconds(3));

            return new DetailDataListUseCaseResponse(ResponseResultType.Success, string.Empty, filmDirectors);
        }
    }

    internal static class FilmDirectorCache
    {
        internal static readonly Dictionary<int, UserDetail> Cache
            = new Dictionary<int, UserDetail>
                  {
                      {
                          0
                          , new UserDetail
                                {
                                    Name          = "George Andrew Romero"
                                    , Age         = 77
                                    , Masterpiece = "Dawn of the Dead"
                                }
                      }
                      ,
                      {
                          1
                          , new UserDetail
                                {
                                    Name          = "Steven Spielberg"
                                    , Age         = 71
                                    , Masterpiece = "Jaws"
                                }
                      }
                      ,
                      {
                          2
                          , new UserDetail
                                {
                                    Name          = "Quentin Jerome Tarantino"
                                    , Age         = 55
                                    , Masterpiece = "Pulp Fiction"
                                }
                      }
                      ,
                      {
                          3
                          , new UserDetail
                                {
                                    Name          = "Christopher Nolan"
                                    , Age         = 48
                                    , Masterpiece = "Memento"
                                }
                      }
                      ,
                      {
                          4
                          , new UserDetail
                                {
                                    Name          = "George Miller"
                                    , Age         = 73
                                    , Masterpiece = "Mad Max"
                                }
                      }
                      ,
                      {
                          5
                          , new UserDetail
                                {
                                    Name          = "Stanley Kubrick"
                                    , Age         = 70
                                    , Masterpiece = "The Shining"
                                }
                      }
                      ,
                      {
                          6
                          , new UserDetail
                                {
                                    Name          = "Timothy Walter Burton"
                                    , Age         = 60
                                    , Masterpiece = "Alice in Wonderland"
                                }
                      }
                      ,
                      {
                          7
                          , new UserDetail
                                {
                                    Name          = "George Walton Lucas"
                                    , Age         = 74
                                    , Masterpiece = "Star Wars"
                                }
                      }
                      ,
                      {
                          8
                          , new UserDetail
                                {
                                    Name          = "Samuel Marshall Raimi"
                                    , Age         = 59
                                    , Masterpiece = "The Evil Dead"
                                }
                      }
                      ,
                      {
                          9
                          , new UserDetail
                                {
                                    Name          = "Eli Roth"
                                    , Age         = 46
                                    , Masterpiece = "Hostel"
                                }
                      }
                  };
    }
}