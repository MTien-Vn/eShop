<template>
  <div>
        <base-header type="gradient-success" class="pb-6 pb-8 pt-5 pt-md-8">
           <tabs>
            <tab-pane title="Vendor" path='vendor'></tab-pane>
            <tab-pane title="Item" path='item'></tab-pane>
            <tab-pane title="Invoice" path='invoice'></tab-pane>
          </tabs>
          <!-- <router-link to="/importedItem/vendor" class="tab-pane fade"></router-link>
          <router-link to="/importedItem/item"></router-link> -->
        </base-header>

        <!-- <div class="container-fluid mt--7">
            <div class="row">
                <div class="col">
                    <VendorList title="Vendor list"></VendorList>
                </div>
            </div>
        </div> -->

        <div class="container-fluid mt--7">
            <div class="row">
                <div class="col">
                    <router-view></router-view>
                </div>
            </div>
        </div>

    </div>
</template>

<script>
import TabPane from '../../components/Tabs/TabPane.vue';
import { router } from '../../router/router';
  //import VendorList from './VendorList.vue'
  export default {
    name: 'ImportedItem',
    components: {
        TabPane,
      
     // VendorList
    },
    created(){
        //router.push('importedItem/vendor');
        router.push('importItem/item');
    }
  };
</script>