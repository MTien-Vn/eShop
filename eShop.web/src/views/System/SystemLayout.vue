<template>
<div>
    <base-header type="gradient-success" class="pb-6 pb-8 pt-5 pt-md-8">
           <tabs>
            <tab-pane title="Users" path='users'></tab-pane>
            <tab-pane title="AssignRole" path='assignRole'></tab-pane>
          </tabs>
    </base-header>
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
export default {
  name: 'System',
  components: {
    TabPane,
  },
  created(){
    router.push('system/users');
  }
}
</script>