(function initialFunction() {

            var app = Sammy(function () {
                this.get("#/", function () {
                    if (controller.isLoggedIn()) {
                        window.location = "#/logged-in";
                    }
                    else {
                        controls.loadLoginForm("#main-content");                       
                    }
                });

                this.get("#/logged-in", function () {                  
                    controls.loadLoggedForm("#main-content");                   
                });

                this.get("#/posts", function () {
                    controller.mediatePosts("#main-content", "#error-console");
                });

                this.get("#/posts/create", function () {
                    controls.loadPostForm("#main-content");
                });

                this.get("#/posts/:tags", function () {
                    var tags = this.params["tags"];
                    var tagArray = tags.split(',');
                    controller.getPostsByTags(tagArray, "#main-content", "#error-console");
                });

                this.get("#/post/:id", function () {
                    var postId = this.params["id"];
                    controller.getPostDetails(postId, "#main-content", "#error-console");
                });

                this.get("#/post/:id/comment", function () {
                    var postId = this.params["id"];
                    controls.visualizeCommentForm(postId, "#main-content");
                });
            });

            $(function () {
                app.run("#/");
            });
        })();
