$(document).ready(
    function Preloading() {
        loadGenre();      
        loadArtist();
        loadAlbumType();
    });
//流派菜单实现
//select的使用技巧：https://www.w3cschool.cn/htmltags/tag-select.html
function loadGenre() {
    var GenreSelectenID = document.getElementById("CurrentGenreSelectedId").value;
    $.ajax({        
        type: 'POST',
        async: true,
        url: '/ExampleAlbum/GetGenreList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {            
            var contentString = '';
            var object = data;
            $.each(
                object,
                function (item) {
                    //alert(GenreSelectenID.value);
                    if (object[item].Id == GenreSelectenID)
                    {                        
                        contentString += "<option value='" + object[item].Id + "' selected>" + object[item].Name + "</option>";
                    }
                    else
                    {
                        contentString += "<option value='" + object[item].Id + "'>" + object[item].Name + "</option>";
                    }
                });
            contentString = "<select id='GenreId' name='GenreId' class='form-control'>" + contentString + "</select>";
            
            $('#GenreSelectList').html(contentString);
            $('#GenreSelectList').val($('CurrentGenreSelectedId').val());//被选项
        }
    })
}
//歌手菜单实现
//select的使用技巧：https://www.w3cschool.cn/htmltags/tag-select.html
function loadArtist() {
    var ArtistSelectenID = document.getElementById("CurrentArtistSelectedId").value;
    $.ajax({
        type: 'POST',
        async: true,
        url: '/ExampleAlbum/GetArtistList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {
            var contentString = '';
            var object = data;
            $.each(
                object,
                function (item) {
                    //alert(ArtistSelectenID.value);
                    if (object[item].Id == ArtistSelectenID)
                    {
                        
                        contentString += "<option value='" + object[item].Id + "' selected>" + object[item].Name + "</option>";
                    }
                    else
                    {
                        contentString += "<option value='" + object[item].Id + "'>" + object[item].Name + "</option>";
                    }
                    
                });
            contentString = "<select id='ArtistId' name='ArtistId' class='form-control'>" + contentString + "</select>";
            
            $('#ArtistSelectList').html(contentString);
            $('#ArtistSelectList').val($('CurrentArtistSelectedId').val());//被选项
        }
    })
}
//专辑类型实现
//select的使用技巧：https://www.w3cschool.cn/htmltags/tag-select.html
function loadAlbumType() {
    var AlbumTypeSelectenID = document.getElementById("CurrentAlbumTypeSelectedId").value;
    $.ajax({
        type: 'POST',
        async: true,
        url: '/ExampleAlbum/GetAlbumTypeList',//调用目标控制器方法
        dataType: 'json',
        success: function (data) {
            var contentString = '';
            var object = data;
            $.each(
                object,
                function (item) {
                    //alert(AlbumTypeSelectenID.value);
                    if (object[item].Id == AlbumTypeSelectenID)
                    {
                       
                        contentString += "<option value='" + object[item].Id + "' selected>" + object[item].Name + "</option>";
                    }
                    else
                    {
                        contentString += "<option value='" + object[item].Id + "'>" + object[item].Name + "</option>";
                    }
                    
                });
            contentString = "<select id='AlbumTypeId' name='AlbumTypeId' class='form-control'>" + contentString + "</select>";
            
            $('#AlbumTypeSelectList').html(contentString);
            $('#AlbumTypeSelectList').val($('CurrentAlbumTypeSelectedId').val());//被选项
        }
    })
}
//图片上传实现
function upFileImg() {
    var files = $('#UploadedFile').prop('files');//需要检查前端Input标签的Id名，检查input类型是否为files
    var data = new FormData();
    data.append('imgFile', files[0]);
    $.ajax({
        type: 'POST',
        url: "/ExampleAlbum/UploadImgFile",//跳转控制器方法
        data: data,
        dataType: 'json',//注意：不写成josn
        cache: false,
        processData: false,
        contentType: false,
        success: function (result) {//ret:控制器回传的JSON数据
            alert(result.upMessage);//是否获取控制器生成的图片文件名
            $("#UrlString").val(result.imgUrlString);
        }
    });
}
//图片预览实现
function singleFileSelected(evt) {
    var selectedFile = ($("#UploadedFile"))[0].files[0];//FileControl.files[0];需要检查前端Input标签的id名
    if (selectedFile) {
        var FileSize = 0;
        var imageType = /image.*/;
        if (selectedFile.size > 1048576) {
            FileSize = math.round(selectedFile.size * 100 / 148576) / 100 + "MB";
        }
        else if (selectedFile.size > 1024) {
            FileSize = Math.round(selectedFile.size * 100 / 1024) / 100 + "KB";
        }
        else {
            FileSize = selectedFile.size + "Bytes";
        }
        $("#FileName").text("文件名：" + selectedFile.name);
        $("#FileSize").text("大小：" + FileSize);
        $("#FileType").text("类型：" + selectedFile.type);
    }
    if (selectedFile.type.match(imageType)) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("#Imagecontainer").empty();
            var dataURL = reader.result;
            var img = new Image();
            img.src = dataURL;
            img.className = "thumb";
            $("#Imagecontainer").append(img);
        };
        reader.readAsDataURL(selectedFile);
    }
}

//function gofor()
//{
//    alert('进入获取脚本');   
    
    
//    alert(GenreSelectenID);
//}