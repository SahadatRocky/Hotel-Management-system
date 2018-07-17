$(function () {
    $('#btnLoad').click(function () {
        $.ajax({
           
            url: 'http://localhost:11608/api/Room',
            method: 'GET',
            success: function (deptList) {
                deptList.forEach(function (dept) {
                    var row = "<li><a href='#'>" + dept.roomNumber + "</a></li>";
                    $('#Roomlist').append(row);


                });
                
            }
        });
    });
});