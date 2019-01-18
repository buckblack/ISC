CKEDITOR.replace('binh_luan', {
    customConfig: 'config_binh_luan.js'
});
CKEDITOR.replace('binh_luan2', {
    customConfig: 'config_binh_luan.js'
});

check_img.onclick = () => {
    var kq = document.getElementsByClassName('table_hinh')
    if (check_img.checked == true)
        for (var i = 0; i < kq.length; i++) {
            kq[i].style.display = "none"
            console.log(kq[i].innerHTML);
        }
    else
        for (var i = 0; i < kq.length; i++) {
            kq[i].style.display = "block"
        }
}
check_status.onclick = () => {
    var kq = document.getElementsByClassName('table_status')
    if (check_status.checked == true)
        for (var i = 0; i < kq.length; i++) {
            kq[i].style.display = "none"
            console.log(kq[i].innerHTML);
        }
    else
        for (var i = 0; i < kq.length; i++) {
            kq[i].style.display = "block"
        }
}
btn_capnhat.onclick = () => {
    btn_close_detai.click()
}

function chon_ban(ma_ban) {
    var ban=document.getElementById(`ban_${ma_ban}`)
    var img=ban.getAttribute("src");
    ban.setAttribute("src","images/chair2.png") 
}

function chon_mon(ma_mon) {
    ds_mon.innerHTML+=`
    <tr>
        <th class="align-middle">1</th>
        <td class="align-middle"><i class="fa fa-remove text-danger"></i></td>
        <td class="align-middle">Tên món ăn ABC</td>
        <td class="align-middle"><input class="form-control hoa-don" type="number" value="1"></td>
        <td class="align-middle">30,000</td>
        <td class="align-middle"><strong>30,000</strong></td>
    </tr>
    `
}