var persister = (function (){
    var appKey = '3X9TEZuTGQlLnMyH';
    var connector = new Everlive(appKey);

    function authenticateIfNeccessary() {
        if (connector.setup.token == null) {
            connector.setup.token = localStorage.getItem("token");
        }
    }

    function login(userData, success, failure) {
        connector.Users.login(userData.username, 
            userData.password, 
                function (data) {
                    success(data);                   
                },
                function (error) {
                    failure(error);
                }
        );
    }

    function register(userData, success, failure) {
        connector.Users.register(userData.username,
            userData.password,
            {
                Email: userData.email,
                DisplayName: userData.nickname
            },
            function (data) {
                success(data);
            },
            function (err) {
                failure(err);
            });
    }

    function logout(success, failure) {
        authenticateIfNeccessary();
        connector.Users.logout(
                function (data) {
                    success(data);
                },
                function (error) {
                    failure(error);
                }
        );
    }

    function getAllPosts(success, failure) {
        authenticateIfNeccessary();
        var data = connector.data('Posts');
        data.get().then(function (data) {
            success(data);
        },
        function (err) {
            failure(err);
        });
    }
    
    function getPostsByTags(tags, success, failure) {
        authenticateIfNeccessary();
        var filter = new Everlive.Query();
        filter.where().all('Tags', tags);
        var data = Everlive.$.data('Posts');
        data.get(filter)
            .then(function(data){
                success(data);
            },
            function(err){
                failure(err);
            });
    }

    function createPost(post, success, failure) {
        authenticateIfNeccessary();
        var data = connector.data('Posts');
        var tagArray = post.tags.split(',');

        data.create({
            'Title': post.title,
            'Content': post.content,
            'Tags': tagArray,
            'PostDate': new Date()
        },
            function (data) {
                success(data);
            },
            function (err) {
                failure(err);
            }
        );
    }

    function getPostById(id, success, failure) {
        authenticateIfNeccessary();
        var data = connector.data('Posts');
        data.getById(id)
            .then(function (data) {
                success(data);
            },
            function (err) {
                failure(error);
            });
    }

    function getPostComments(id, success, failure) {
        authenticateIfNeccessary();
        var filter = new Everlive.Query();
        filter.where().eq('Post', id);
        var data = connector.data('Comments');
        data.get(filter)
            .then(function (data) {
                success(data);
            },
            function (err) {
                failure(err);
            });
    }

    function createComment(comment, success, failure) {
        authenticateIfNeccessary();
        var data = connector.data('Comments');
        data.create({
            'Content': comment.content,
            'Post': comment.postId
        },
           function (data) {
               success(data);
           },
           function (err) {
               failure(err);
           }
       );
    }


    return {
        login: login,
        register: register,
        logout: logout,
        getAllPosts: getAllPosts,
        getPostsByTags: getPostsByTags,
        createPost: createPost,
        getPostById: getPostById,
        getPostComments: getPostComments,
        createComment: createComment
    }
})();