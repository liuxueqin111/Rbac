<template>
<div>
<el-form ref="form" :model="form" label-width="80px">
  <el-form-item label="">
      <el-cascader
    :options="options"
    :props="{ checkStrictly: true }"
    ref="tree"
    clearable></el-cascader>
  </el-form-item>
  <el-form-item label="菜单名称">
    <el-input v-model="form.menuname"></el-input>
  </el-form-item>
  <el-form-item label="链接">
    <el-input v-model="form.linkurl"></el-input>
  </el-form-item>
  <el-form-item>
    <el-button type="primary" @click="onSubmit">添加</el-button>
    <el-button>取消</el-button>
  </el-form-item>
</el-form>
</div>
</template>
<script>
  export default {
    data() {
      return {
        options:[],
        form: {
          menuname: '',
          ParentId:0,
          linkurl: '',
        }
      }
    },
    methods: {
      onSubmit() {
        this.form.ParentId = this.$refs["tree"].getCheckedNodes()[0].value;
        this.$axios.post('https://localhost:44340/api/VUE/Add',this.form)
        .then(res =>{
            if(res.data > 0)
            {
                this.$message.success('添加成功');
                this.$emit("addtable",true);
            }
        })
      },
      GetShow(){
        this.$axios.get('https://localhost:44340/api/VUE/GetList')
        .then(res =>{
            var reg = new RegExp('\\,"children":\\[]',"g");
        this.options = JSON.parse(JSON.stringify(res.data).replace(reg,""));
        })
      }
    },
    created(){
        this.GetShow();
    }
  }
</script>