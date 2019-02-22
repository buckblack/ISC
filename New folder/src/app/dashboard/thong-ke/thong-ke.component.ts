import { Chart } from 'angular-highcharts';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';


@Component({
  selector: 'app-thong-ke',
  templateUrl: './thong-ke.component.html',
  styleUrls: ['./thong-ke.component.css']
})
export class ThongKeComponent implements OnInit {
  chart = new Chart({
    lang: {
      numericSymbols: [` Ngàn`, ` Triệu`],
      numericSymbolMagnitude: 1000,
      decimalPoint: ',', ///phân cách thập phân
      thousandsSep: '.' ///hàng ngàn
    },
    chart: {
      style: {
        fontFamily: `tahoma`, /// chỉnh font cho chữ thống dc đúng
        fontSize: '16px'
      },
      type: 'column',
      plotBorderWidth: 1
    },
    title: {
      text: 'Tiêu đề Biểu đồ',
      align: 'center',
      style: {
        color: 'red',
        fontWeight: 'bold',
        fontSize: '1.5rem'
      },
      y: 20
    },
    subtitle: {
      text: 'Tiêu đề Phụ'
    },
    xAxis: {
      categories: ['Táo', 'Chuối', 'Cam', 'Chanh']
    },
    yAxis: {
      title: {
        text: 'Số lượng Bán',

        style: {
          color: 'blue',
          fontWeight: 'bold',
          fontSize: '1rem'
        }

      }
    },
    credits: {
      enabled: false
    },
    series: [
      {
        name: 'Tèo',
        data: [1, 0, 4, 10],
        color: 'red'
      } as any,
      {
        name: 'Tý',
        data: [5, 7, 3, 0],
        color: 'green'
      } as any,
      {
        name: 'Mận',
        data: [0, 0, 0, 10],
        color: 'blue'
      } as any
    ]
  });
  constructor(private titleService: Title) { }
  ngOnInit() {
    this.titleService.setTitle('Thống kê');
  }
  // add point to chart serie
  add() {
    this.chart.addPoint(Math.floor(Math.random() * 10));
  }

}
