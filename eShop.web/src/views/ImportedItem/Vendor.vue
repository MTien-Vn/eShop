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
          <th>Vendor Code</th>
          <th>Vendor name</th>
          <th>Phone number</th>
          <th>Email</th>
          <th>Address</th>
          <th></th>
        </template>

        <template slot-scope="{row}">
          <th scope="row">
            <div class="align-items-center">
              {{row.vendor_code}}
            </div>
          </th>
          <td>
            <div class="align-items-center">
              {{row.vendor_name}}
            </div>
          </td>
          <td>
            <div class="align-items-center">
              {{row.phone_number}}
            </div>
          </td>
          <td>
            <div class="align-items-center">
              {{row.email}}
            </div>
          </td>
          <td>
            <div class="align-items-center">
              {{row.address}}
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

    <div class="card-footer d-flex justify-content-end"
         :class="type === 'dark' ? 'bg-transparent': ''">
      <base-pagination total = "total_record" ></base-pagination>
    </div>

  </div>
</template>
<script>
import vendorService from '../../service/ImportedItem/vendorService';

  export default {
    name: 'VendorList',
    props: {
      type: {
        type: String
      },
      title: String
    },
    data() {
      return {
        tableData: [],
        total_record: Number
      }
    },
    methods: {
      initData(res){
        this.tableData = res.items;
        this.total_record = res.total_record;
      }
    },
    async created() {
      var res = await vendorService.getVendors(1,10);
      this.initData(res.data);
    }
  }
</script>
<style>
</style>
