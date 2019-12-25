$(document).ready(
    function Preloading() {
        getPicUrlString();//加载动态轮播图方法
        getAlbums();//加载轮播列表实现
    });

//轮播图片读库实现
function getPicUrlString() {
    $.ajax({
        type: 'POST',
        async: true,
        url: "/MusicIndex/GetPics",
        datatype: 'json',
        success: function (data) {
            var divContent = '';
            $.each(
                data,
                function (item) {
                    if (item == 0) {
                        divContent += "<div class='item active'>";
                        divContent += "<img src='/Pics/" + data[item] + "'   />"
                        divContent += "</div>";
                    } else {
                        divContent += "<div class='item'>";
                        divContent += "<img src='/Pics/" + data[item] + "'   />"
                        divContent += "</div>";
                    }
                });
            divContent = "<div class='carousel-inner' role='listbox'>" + divContent + "</div>";
            $("#carousel").html(divContent);
        }
    })
}

//轮播列表实现
function getAlbums() {

    $.ajax({
        type: 'POST',
        async: true,
        url: "/MusicIndex/GetMusicAlbums",
        datatype: 'json',
        success: function (data) {
            var divContent = '';//回传的HTML字符组装
            var divContent1 = '';//第一列表HTML字符组装
            var divContent2 = '';//第二列表HTML字符组装
            var hrefString = '/MusicIndex/Detail/';
            var count = 0;

            divContent+="<div class='carousel-inner' role='listbox'>";

            divContent1+="<div class='item active'>";
            divContent1+="<div class='row'>";

            divContent2+="<div class='item'>";
            divContent2+="<div class='row'>";

            $.each(
                data,
                function(item)
                {
                    if(count<5){
                        divContent1+="<div class='col-md-2'>";
                        divContent1 += "<div class='thumbnail'>";
                        divContent1 += "<a href='" + hrefString + data[item].Id+"'>";
                        divContent1 += " <img src='/Pics/" + data[item].UrlString + "' class='img-responsive' />";
                        divContent1 += "</a>";
                        divContent1+="</div></div>";
                        count++;
                    }else{
                        divContent2+="<div class='col-md-2'>";
                        divContent2 += "<div class='thumbnail'>";
                        divContent2 += "<a href='" + hrefString + data[item].Id + "'>";
                        divContent2 += " <img src='/Pics/" + data[item].UrlString + "' class='img-responsive' />";
                        divContent2 += "</a>";
                        divContent2+="</div></div>";
                    }
                });
            divContent1+="</div></div>";
            divContent2+="</div></div>";
            
            divContent += divContent1 + divContent2 + "</div>";
           
            $('#carousel-list').html(divContent);
        }
    })
}

//$('table tbody').on('click', 'tr', function () {
//    alert("点赞成功！谢谢您的支持！");
//    var Id = $('#item.Id').val();
//    $.ajax({
//        type: 'post',
//        async: true,
//        datatype: 'text',
//        data: { "id": Id },//url方法调用的参数传值，引号内容是方法形参名，后面跟传输值
//        url: "/MusicIndex/AddCTR",
//        datatype:'json'
//    })
//})

function AddCTR() {
    window.alert("点赞成功！");
}