<template>
  <div class="content">
    <div class="md-layout">
      <div
        class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-33"
      >
        <!-- <chart-card
          :chart-data="dailySalesChart.data"
          :chart-options="dailySalesChart.options"
          :chart-type="'Line'"
          data-background-color="blue"
        >
          <template slot="content">
            <h4 class="title">Daily Sales</h4>
            <p class="category">
              <span class="text-success"
                ><i class="fas fa-long-arrow-alt-up"></i> 55%
              </span>
              increase in today sales.
            </p>
          </template>

          <template slot="footer">
            <div class="stats">
              <md-icon>access_time</md-icon>
              updated 4 minutes ago
            </div>
          </template>
        </chart-card> -->
         <chart-card
          :chart-data="revenueByMonth.data"
          :chart-options="revenueByMonth.options"
          :chart-responsive-options="revenueByMonth.responsiveOptions"
          :chart-type="'Bar'"
          data-background-color="blue"
        >
          <template slot="content">
            <h4 class="title">Revenue By Month</h4>
            <p class="category">
              Unit: million(VND)
            </p>
          </template>

          <template slot="footer">
            <div class="stats">
              <md-icon>access_time</md-icon>
              updated 10 days ago
            </div>
          </template>
        </chart-card>
      </div>
      <div
        class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-33"
      >
        <chart-card
          :chart-data="totalAmountImportedItemByMonth.data"
          :chart-options="totalAmountImportedItemByMonth.options"
          :chart-responsive-options="totalAmountImportedItemByMonth.responsiveOptions"
          :chart-type="'Bar'"
          data-background-color="red"
        >
          <template slot="content">
            <h4 class="title">Total Amount Imported Item By Month</h4>
            <p class="category">
              Unit: million(VND)
            </p>
          </template>

          <template slot="footer">
            <div class="stats">
              <md-icon>access_time</md-icon>
              updated 10 days ago
            </div>
          </template>
        </chart-card>
      </div>
      <div
        class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-33"
      >
        <!-- <chart-card
          :chart-data="dataCompletedTasksChart.data"
          :chart-options="dataCompletedTasksChart.options"
          :chart-type="'Line'"
          data-background-color="green"
        >
          <template slot="content">
            <h4 class="title">Completed Tasks</h4>
            <p class="category">
              Last Campaign Performance
            </p>
          </template>

          <template slot="footer">
            <div class="stats">
              <md-icon>access_time</md-icon>
              campaign sent 26 minutes ago
            </div>
          </template>
        </chart-card> -->
         <chart-card
          :chart-data="profitbyMonth.data"
          :chart-options="profitbyMonth.options"
          :chart-responsive-options="profitbyMonth.responsiveOptions"
          :chart-type="'Bar'"
          data-background-color="green"
        >
          <template slot="content">
            <h4 class="title">Profit By Month</h4>
            <p class="category">
              Unit: million(VND)
            </p>
          </template>

          <template slot="footer">
            <div class="stats">
              <md-icon>access_time</md-icon>
              updated 10 days ago
            </div>
          </template>
        </chart-card>
      </div>
      <div
        class="md-layout-item md-medium-size-50 md-xsmall-size-100 md-size-25"
      >
        <stats-card data-background-color="blue">
          <template slot="header">
            <md-icon>store</md-icon>
          </template>

          <template slot="content">
            <p class="category">Total Revenue</p>
            <h3 class="title">{{this.totalRevenue}}</h3>
          </template>

          <template slot="footer">
            <div class="stats">
              <md-icon>date_range</md-icon>
              Last 24 Hours
            </div>
          </template>
        </stats-card>
      </div>
      <div
        class="md-layout-item md-medium-size-50 md-xsmall-size-100 md-size-25"
      >
        <stats-card data-background-color="red">
          <template slot="header">
            <md-icon>content_copy</md-icon>
          </template>

          <template slot="content">
            <p class="category">Total Cost</p>
            <h3 class="title">
              {{this.totalCost}}
            </h3>
          </template>

          <!-- <template slot="footer">
            <div class="stats">
              <md-icon class="text-danger">warning</md-icon>
              <a href="#pablo">Get More Space...</a>
            </div>
          </template> -->
          <template slot="footer">
            <div class="stats">
              <md-icon>date_range</md-icon>
              Last 24 Hours
            </div>
          </template>
        </stats-card>
      </div>
      <div
        class="md-layout-item md-medium-size-50 md-xsmall-size-100 md-size-25"
      >
        <stats-card data-background-color="green">
          <template slot="header">
            <md-icon>info_outline</md-icon>
          </template>

          <template slot="content">
            <p class="category">Total profit</p>
            <h3 class="title">{{this.totalProfit}}</h3>
          </template>

          <!-- <template slot="footer">
            <div class="stats">
              <md-icon>local_offer</md-icon>
              Tracked from Github
            </div>
          </template> -->
          <template slot="footer">
            <div class="stats">
              <md-icon>date_range</md-icon>
              Last 24 Hours
            </div>
          </template>
        </stats-card>
      </div>
      <div
        class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-50"
      >
        <!-- <md-card>
          <md-card-header data-background-color="orange">
            <h4 class="title">Employees Stats</h4>
            <p class="category">New employees on 15th September, 2016</p>
          </md-card-header>
          <md-card-content>
            <ordered-table table-header-color="orange"></ordered-table>
          </md-card-content>
        </md-card> -->
      </div>
      <div
        class="md-layout-item md-medium-size-100 md-xsmall-size-100 md-size-50"
      >
        <!-- <nav-tabs-card>
          <template slot="content">
            <span class="md-nav-tabs-title">Tasks:</span>
            <md-tabs class="md-success" md-alignment="left">
              <md-tab id="tab-home" md-label="Bugs" md-icon="bug_report">
                <nav-tabs-table></nav-tabs-table>
              </md-tab>

              <md-tab id="tab-pages" md-label="Website" md-icon="code">
                <nav-tabs-table></nav-tabs-table>
              </md-tab>

              <md-tab id="tab-posts" md-label="server" md-icon="cloud">
                <nav-tabs-table></nav-tabs-table>
              </md-tab>
            </md-tabs>
          </template>
        </nav-tabs-card> -->
      </div>
    </div>
  </div>
</template>

<script>
import {
  StatsCard,
  ChartCard,
  //NavTabsCard,
  //NavTabsTable,
  //OrderedTable
} from "@/components";
import satisticService from '../service/statisticService';

export default {
  components: {
    StatsCard,
    ChartCard,
    //NavTabsCard,
    //NavTabsTable,
    //OrderedTable
  },
  data() {
    return {
      totalRevenue: 0,
      totalCost: 0,
      totalProfit: 0,
      curYear: 0,
      maxTotalAmount: 0,
      revenueByMonth: {
         data: {
          labels: [
            "Ja",
            "Fe",
            "Ma",
            "Ap",
            "Mai",
            "Ju",
            "Jul",
            "Au",
            "Se",
            "Oc",
            "No",
            "De"
          ],
          series: [[-1000]]
        },
        options: {
          axisX: {
            showGrid: false
          },
          low: 0,
          high: this.maxTotalAmount,
          chartPadding: {
            top: 0,
            right: 5,
            bottom: 0,
            left: 0
          }
        },
        responsiveOptions: [
          [
            "screen and (max-width: 640px)",
            {
              seriesBarDistance: 5,
              axisX: {
                labelInterpolationFnc: function(value) {
                  return value[0];
                }
              }
            }
          ]
        ]
      },
      profitbyMonth: {
         data: {
          labels: [
            "Ja",
            "Fe",
            "Ma",
            "Ap",
            "Mai",
            "Ju",
            "Jul",
            "Au",
            "Se",
            "Oc",
            "No",
            "De"
          ],
          series: []
        },
        options: {
          axisX: {
            showGrid: false
          },
          low: 0,
          high: this.maxTotalAmount,
          chartPadding: {
            top: 0,
            right: 5,
            bottom: 0,
            left: 0
          }
        },
        responsiveOptions: [
          [
            "screen and (max-width: 640px)",
            {
              seriesBarDistance: 5,
              axisX: {
                labelInterpolationFnc: function(value) {
                  return value[0];
                }
              }
            }
          ]
        ]
      },
      totalAmountImportedItemByMonth: {
        data: {
          labels: [
            "Ja",
            "Fe",
            "Ma",
            "Ap",
            "Mai",
            "Ju",
            "Jul",
            "Au",
            "Se",
            "Oc",
            "No",
            "De"
          ],
          series: []
        },
        options: {
          axisX: {
            showGrid: false
          },
          low: 0,
          high: this.maxTotalAmount,
          chartPadding: {
            top: 0,
            right: 5,
            bottom: 0,
            left: 0
          }
        },
        responsiveOptions: [
          [
            "screen and (max-width: 640px)",
            {
              seriesBarDistance: 5,
              axisX: {
                labelInterpolationFnc: function(value) {
                  return value[0];
                }
              }
            }
          ]
        ]
      }
    };
  },
  methods: {
    getCurrentyear(){
      var curYear = new Date().getFullYear();
      this.curYear = curYear;
    },
    async convertData(){
      var res = await satisticService.statisticTotalAmountByMonth(this.curYear);
      var localSeri = res.Data[0];
      this.maxTotalAmount = Math.max.apply(null, localSeri)/1000000;
      localSeri.january = localSeri.january/1000000;
      localSeri.fecbuary = localSeri.fecbuary/1000000; 
      localSeri.march = localSeri.march/1000000; 
      localSeri.april = localSeri.april/1000000; 
      localSeri.may = localSeri.may/1000000; 
      localSeri.june = localSeri.june/1000000; 
      localSeri.july = localSeri.july/1000000;
      localSeri.august = localSeri.august/1000000; 
      localSeri.sep = localSeri.sep/1000000; 
      localSeri.oct = localSeri.oct/1000000; 
      localSeri.nov = localSeri.nov/1000000; 
      localSeri.december = localSeri.december/1000000;
      var series = [localSeri.january, localSeri.fecbuary, localSeri.march, localSeri.april, localSeri.may, localSeri.june, localSeri.july, localSeri.august, localSeri.sep, localSeri.oct, localSeri.nov, localSeri.december];
      this.totalAmountImportedItemByMonth.data.series[0] = series;
    }
  },
  async created() {
    this.getCurrentyear();
    this.convertData();
  },
};
</script>
