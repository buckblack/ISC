$(document).ready(function () {
  $('#alert-login').hide();
});

function click_login(){
  window.setTimeout(function() {
    $("#alert-login").fadeTo(500, 0).slideUp(500, function(){
        $(this).remove(); 
    });
  }, 4000);
}
function check_ghichu() {
  var kq = document.querySelectorAll('.table_ghichu')
  var check = document.getElementById('check_ghichu')
  check.onchange = function () {
    if (check.checked == false)
      for (var i = 0; i < kq.length; i++) {
        kq[i].classList.add("d-none");
      }
    else
      for (var i = 0; i < kq.length; i++) {
        kq[i].classList.remove("d-none");
      }
  }
}





function check_ban() {
  var kq = document.querySelectorAll('.table_ban')
  var check = document.getElementById('check_ban')
  check.onchange = () => {

    if (check.checked == false)
      for (var i = 0; i < kq.length; i++) {
        kq[i].classList.add("d-none");
      }
    else
      for (var i = 0; i < kq.length; i++) {
        kq[i].classList.remove("d-none");
      }
  }


};

function check_img() {
  var kq = document.querySelectorAll('.table_hinh')
  var check = document.getElementById('check_img')
  check.onchange = () => {

    if (check.checked == false)
      for (var i = 0; i < kq.length; i++) {
        kq[i].classList.add("d-none");
      }
    else
      for (var i = 0; i < kq.length; i++) {
        kq[i].classList.remove("d-none");
      }
  }
};

function check_masp() {
  var kq = document.querySelectorAll('.table_masp')
  var check = document.getElementById('check_masp')
  check.onchange = () => {

    if (check.checked == false)
      for (var i = 0; i < kq.length; i++) {
        kq[i].classList.add("d-none");
      }
    else
      for (var i = 0; i < kq.length; i++) {
        kq[i].classList.remove("d-none");
      }
  }
};

function check_status() {
  var kq = document.querySelectorAll('.table_status')
  var check = document.getElementById('check_status')
  check.onchange = () => {

    if (check.checked == false)
      for (var i = 0; i < kq.length; i++) {
        kq[i].classList.add("d-none");
      }
    else
      for (var i = 0; i < kq.length; i++) {
        kq[i].classList.remove("d-none");
      }
  }
};


function cap_nhat_san_pham() {
  $('#btn_capnhat').click(function (e) {
    btn_close_detai.click()
  });

}

function chon_ban(ma_ban) {
  var ban = document.getElementById(`ban_${ma_ban}`)
  var img = ban.getAttribute("src");
  ban.setAttribute("src", "/assets/images/chair2.png")
}

function chon_mon(ma_mon) {
  ds_mon.innerHTML += `
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

//thành phần

function tach_chuoi_thanh_phan(chuoi, kytu) {
  var kq = chuoi.split(kytu);
  return kq;
}

function timthanhphan() {
  sl_tp_up.innerHTML = `
    <option value="1">A: (gr)</option>
    <option value="2">B: (gr)</option>
    <option value="3">C: (gr)</option>
    `
}

function uptodown() {
  var up = document.getElementById('sl_tp_up');
  if (up.value != '') {
    var chuoi = tach_chuoi_thanh_phan(up.options[up.selectedIndex].text, ':')
    sl_tp_down.innerHTML += `<option value="${up.value}">${chuoi[0]}: ${tp_soluong.value}${chuoi[1]}</option>`
    $('#sl_tp_up option:selected').remove();
  }

}

function downtoup() {
  var down = document.getElementById('sl_tp_down');

  if (down.value != '') {
    var chuoi = tach_chuoi_thanh_phan(down.options[down.selectedIndex].text, ':')
    var donvi = tach_chuoi_thanh_phan(chuoi[1], '(')
    donvi = donvi[1].split(')')
    sl_tp_up.innerHTML += `<option value="${down.value}">${chuoi[0]}: (${donvi[0]})</option>`
    $('#sl_tp_down option:selected').remove();
  }

}
//kết thúc thành phần

function xoa_gio_hang(mahd, mamon, soluong) {
  var kq = document.getElementById('tr_gio_hang_' + mahd);
  kq.innerHTML = ``;
}

function doi_so_luong_gio_hang(mahd) {
  var soluong = document.getElementById('soluong_' + mahd);
  var tien = document.getElementById('tongtien_' + mahd);
  var gia = document.getElementById('gia_' + mahd);
  tien.innerHTML = Number(soluong.value) * Number(gia.innerHTML);
}


