<template>
  <div>
        <base-header type="gradient-success" class="pb-6 pb-8 pt-5 pt-md-8">
           <tabs>
            <tab-pane title="Vendor"></tab-pane>
            <tab-pane title="Item"></tab-pane>
            <tab-pane title="Invoice"></tab-pane>
          </tabs>
        </base-header>

        <div class="container-fluid mt--7">
            <div class="row">
                <div class="col">
                    <VendorList title="Vendor list"></VendorList>
                </div>
            </div>
        </div>

    </div>
</template>

<script>
  import VendorList from '../ImportedItem/Vendor.vue'
  export default {
    name: 'ImportedItem',
    components: {
      VendorList
    }
  };
</script>