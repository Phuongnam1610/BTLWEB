function onclickitemcate() {
    var mySelect = document.getElementById("cateselect");
    var selectedCategory = mySelect.value;
    console.log(typeof selectedCategory); 
    var tableRows = document.querySelectorAll("#alltopic tbody tr");
    // Lặp qua các hàng trong bảng và kiểm tra giá trị của categoryid
    for (var i = 0; i < tableRows.length; i++) {
        var row = tableRows[i];
        var categoryID = row.className.split(" ")[1];
        console.log(typeof categoryID); 
        console.log(selectedCategory.toString() === categoryID.toString()); 
        // Kiểm tra nếu categoryid trùng với giá trị đã chọn hoặc là "all"
        if (categoryID == selectedCategory || selectedCategory == 1) {
            row.style.display = "table-row"; // Hiển thị hàng
        } else {
            row.style.display = "none"; // Ẩn hàng
        }
    }

}