<template>
<div>
  <el-button type="primary" @click="dialogFormVisible=true">添加</el-button>
  <el-table
    :data="tableData"
    style="width: 100%;margin-bottom: 20px;"
    row-key="menuId"
    border
    default-expand-all
    :tree-props="{children: 'children', hasChildren: 'hasChildren'}">
    <el-table-column
      prop="menuId"
      label="菜单Id"
      sortable
      width="180">
    </el-table-column>
    <el-table-column
      prop="menuName"
      label="菜单名称"
      sortable
      width="180">
    </el-table-column>
    <el-table-column
      prop="linkUrl"
      label="链接">
    </el-table-column>
    <el-table-column label="操作">
      <template slot-scope="scope">
        <el-button
          size="mini"
          @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
          <el-button
          size="mini"
          @click="handleDel(scope.$index, scope.row)">删除</el-button>
        </template>
    </el-table-column>
  </el-table>
  <el-dialog title="添加" :visible.sync="dialogFormVisible">
     <addpros @addtable="addtable" />
  </el-dialog>
  <el-dialog title="修改" :visible.sync="UpddialogFormVisible">
     <updpros @Edit=Edit :formdate=form />
  </el-dialog>
</div>
</template>
<script>
import addpros from '@/views/add.vue'
import updpros from '@/views/Edit.vue'
  export default {
    components: {
    addpros,
    updpros   
  },
    data() {
      return {
        tableData: [],
        dialogFormVisible:false,
        UpddialogFormVisible:false,
        form:{
          tableData:[],
          MenuId:'',
          MenuName:'',
          LinkUrl:'',
          
        }
      }
    },
    methods: {
      GetShow(){
        this.$axios.get('https://localhost:44340/api/VUE/GetAll')
        .then(res =>{
            this.tableData = res.data;
        })
      },
      addtable(val){
        this.dialogFormVisible = !val;
        this.GetShow();
      },
      handleEdit(index, row) 
      {
        this.form.tableData=this.tableData;
        this.form=row;
        this.UpddialogFormVisible=true;
      },
      Edit(){
        this.UpddialogFormVisible = false;
        this.GetShow();
      },
      handleDel(index,row)
      {
        if(confirm('确定要删除吗'))
        {
          if(row.children.length==0)
          {
            this.$axios.post('https://localhost:44340/api/VUE/Del',row)
        .then(res =>{
            if(res.data > 0)
            {
              this.$message.success('删除成功');
              this.GetShow();
            }else{
              this.$message.error('删除失败');
            }
        })
          }
           else
      {
        this.$message("此节点有"+row.children.length+"个子节点请先删除旗下的子节点");
        
      }
          
        }
      }
    },
    created(){
        this.GetShow();
    }
  }
</script>