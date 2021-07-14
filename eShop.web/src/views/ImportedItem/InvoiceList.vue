<template>
  <div class="card shadow"
       :class="type === 'dark' ? 'bg-default': ''">
    <div class="card-header border-0"
         :class="type === 'dark' ? 'bg-transparent': ''">
      <div class="row align-items-center">
        <div class="col">
          <h3 class="mb-0" :class="type === 'dark' ? 'text-white': ''">
            {{title}}
          </h3>
        </div>
      </div>
    </div>

    <div class="table-responsive">
      <base-table class="table align-items-center table-flush"
                  :class="type === 'dark' ? 'table-dark': ''"
                  :thead-classes="type === 'dark' ? 'thead-dark': 'thead-light'"
                  tbody-classes="list"
                  :data="tableData">
        <template slot="columns">
          <th>Invoice Code</th>
          <th>Employee code</th>
          <th>Vendor code</th>
          <th>Amount</th>
          <th>Tax</th>
          <th>Total amount</th>
          <th>Imported date</th>
          <th></th>
        </template>

        <template slot-scope="{row}">
          <th scope="row">
            <div class="align-items-center">
              {{row.invoice_code}}
            </div>
          </th>
          <td>
            <div class="align-items-center">
              {{row.employee_code}}
            </div>
          </td>
          <td>
            <div class="align-items-center">
              {{row.vendor_code}}
            </div>
          </td>
          <td>
            <div class="align-items-center">
              {{row.amount}}
            </div>
          </td>
          <td>
            <div class="align-items-center">
              {{row.tax}}
            </div>
          </td>
          <td>
            <div class="align-items-center">
              {{row.total_amount}}
            </div>
          </td>
          <td>
            <div class="align-items-center">
              {{row.date_imported}}
            </div>
          </td>

          <td class="text-right">
            <base-dropdown class="dropdown"
                           position="right">
              <a slot="title" class="btn btn-sm btn-icon-only text-light" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <i class="fas fa-ellipsis-v"></i>
              </a>

              <template>
                <a class="dropdown-item" href="#">Delete</a>
                <a class="dropdown-item" href="#">Update</a>
              </template>
            </base-dropdown>
          </td>

        </template>

      </base-table>
    </div>

    <div class="card-footer"
         :class="type === 'dark' ? 'bg-transparent': ''">
      <base-pagination :total="total_record" 
                        @changePage="handleChangePage"></base-pagination>
    </div>

  </div>
</template>
<script>
import getInvoices from '../../service/ImportedItem/invoiceService';

  export default {
    name: 'ItemList',
    props: {
      type: {
        type: String
      },
      title: String
    },
    data() {
      return {
        tableData: [],
        total_record: Number,
      }
    },
    methods: {
      async initData(page){
        var res = await getInvoices.getInvoices(page,10);
        res = res.data;
        this.tableData = res.items;
        this.total_record = res.total_record;
      },
      handleChangePage(page){
        this.initData(page);
      }
    },
    created() {
      this.initData(1);
    }
  }
</script>
<style>
</style>
