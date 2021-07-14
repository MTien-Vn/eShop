<template>
  <div class="tab-pane"
       v-show="active"
       :id="id || title"
       :class="{active: active}">
    <router-link
                :to="link.path"
                class="nav-link"
                :target="link.target"
                :href="link.path">
      </router-link>
  </div>
</template>
<script>
export default {
  name: "tab-link",
  props: {
    title: {
      type: String,
      default: "",
      description: "Tab pane title"
    },
    id: {
      type: String,
      default: null,
      description: "Tab pane id"
    },
    link: {
        type: Object,
        default: () => {
          return {
            name: '',
            path: '',
            children: []
          };
        },
        description:
          'Sidebar link. Can contain name, path, icon and other attributes. See examples for more info'
      }
  },
  inject: ["addTab", "removeTab"],
  data() {
    return {
      active: false
    };
  },
  mounted() {
    this.addTab(this);
  },
  destroyed() {
    if (this.$el && this.$el.parentNode) {
      this.$el.parentNode.removeChild(this.$el);
    }
    this.removeTab(this);
  }
};
</script>
<style>
</style>
