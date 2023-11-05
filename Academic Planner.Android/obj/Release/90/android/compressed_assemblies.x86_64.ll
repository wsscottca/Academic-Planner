; ModuleID = 'obj\Release\90\android\compressed_assemblies.x86_64.ll'
source_filename = "obj\Release\90\android\compressed_assemblies.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android"


%struct.CompressedAssemblyDescriptor = type {
	i32,; uint32_t uncompressed_file_size
	i8,; bool loaded
	i8*; uint8_t* data
}

%struct.CompressedAssemblies = type {
	i32,; uint32_t count
	%struct.CompressedAssemblyDescriptor*; CompressedAssemblyDescriptor* descriptors
}
@__CompressedAssemblyDescriptor_data_0 = internal global [197120 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_1 = internal global [184320 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_2 = internal global [14336 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_3 = internal global [166912 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_4 = internal global [2038784 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_5 = internal global [121856 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_6 = internal global [4608 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_7 = internal global [9216 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_8 = internal global [92160 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_9 = internal global [5120 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_10 = internal global [46080 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_11 = internal global [5120 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_12 = internal global [35328 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_13 = internal global [14752 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_14 = internal global [328192 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_15 = internal global [20992 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_16 = internal global [218112 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_17 = internal global [25600 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_18 = internal global [7168 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_19 = internal global [400896 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_20 = internal global [55808 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_21 = internal global [919040 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_22 = internal global [757248 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_23 = internal global [14336 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_24 = internal global [14848 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_25 = internal global [8704 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_26 = internal global [428544 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_27 = internal global [65024 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_28 = internal global [15360 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_29 = internal global [135680 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_30 = internal global [38912 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_31 = internal global [143360 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_32 = internal global [34304 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_33 = internal global [25088 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_34 = internal global [52224 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_35 = internal global [439808 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_36 = internal global [15872 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_37 = internal global [379904 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_38 = internal global [26624 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_39 = internal global [1149952 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_40 = internal global [772096 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_41 = internal global [128640 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_42 = internal global [102912 x i8] zeroinitializer, align 16
@__CompressedAssemblyDescriptor_data_43 = internal global [2063872 x i8] zeroinitializer, align 16


; Compressed assembly data storage
@compressed_assembly_descriptors = internal global [44 x %struct.CompressedAssemblyDescriptor] [
	; 0
	%struct.CompressedAssemblyDescriptor {
		i32 197120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([197120 x i8], [197120 x i8]* @__CompressedAssemblyDescriptor_data_0, i32 0, i32 0); data
	}, 
	; 1
	%struct.CompressedAssemblyDescriptor {
		i32 184320, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([184320 x i8], [184320 x i8]* @__CompressedAssemblyDescriptor_data_1, i32 0, i32 0); data
	}, 
	; 2
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14336 x i8], [14336 x i8]* @__CompressedAssemblyDescriptor_data_2, i32 0, i32 0); data
	}, 
	; 3
	%struct.CompressedAssemblyDescriptor {
		i32 166912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([166912 x i8], [166912 x i8]* @__CompressedAssemblyDescriptor_data_3, i32 0, i32 0); data
	}, 
	; 4
	%struct.CompressedAssemblyDescriptor {
		i32 2038784, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2038784 x i8], [2038784 x i8]* @__CompressedAssemblyDescriptor_data_4, i32 0, i32 0); data
	}, 
	; 5
	%struct.CompressedAssemblyDescriptor {
		i32 121856, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([121856 x i8], [121856 x i8]* @__CompressedAssemblyDescriptor_data_5, i32 0, i32 0); data
	}, 
	; 6
	%struct.CompressedAssemblyDescriptor {
		i32 4608, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([4608 x i8], [4608 x i8]* @__CompressedAssemblyDescriptor_data_6, i32 0, i32 0); data
	}, 
	; 7
	%struct.CompressedAssemblyDescriptor {
		i32 9216, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([9216 x i8], [9216 x i8]* @__CompressedAssemblyDescriptor_data_7, i32 0, i32 0); data
	}, 
	; 8
	%struct.CompressedAssemblyDescriptor {
		i32 92160, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([92160 x i8], [92160 x i8]* @__CompressedAssemblyDescriptor_data_8, i32 0, i32 0); data
	}, 
	; 9
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([5120 x i8], [5120 x i8]* @__CompressedAssemblyDescriptor_data_9, i32 0, i32 0); data
	}, 
	; 10
	%struct.CompressedAssemblyDescriptor {
		i32 46080, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([46080 x i8], [46080 x i8]* @__CompressedAssemblyDescriptor_data_10, i32 0, i32 0); data
	}, 
	; 11
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([5120 x i8], [5120 x i8]* @__CompressedAssemblyDescriptor_data_11, i32 0, i32 0); data
	}, 
	; 12
	%struct.CompressedAssemblyDescriptor {
		i32 35328, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([35328 x i8], [35328 x i8]* @__CompressedAssemblyDescriptor_data_12, i32 0, i32 0); data
	}, 
	; 13
	%struct.CompressedAssemblyDescriptor {
		i32 14752, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14752 x i8], [14752 x i8]* @__CompressedAssemblyDescriptor_data_13, i32 0, i32 0); data
	}, 
	; 14
	%struct.CompressedAssemblyDescriptor {
		i32 328192, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([328192 x i8], [328192 x i8]* @__CompressedAssemblyDescriptor_data_14, i32 0, i32 0); data
	}, 
	; 15
	%struct.CompressedAssemblyDescriptor {
		i32 20992, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([20992 x i8], [20992 x i8]* @__CompressedAssemblyDescriptor_data_15, i32 0, i32 0); data
	}, 
	; 16
	%struct.CompressedAssemblyDescriptor {
		i32 218112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([218112 x i8], [218112 x i8]* @__CompressedAssemblyDescriptor_data_16, i32 0, i32 0); data
	}, 
	; 17
	%struct.CompressedAssemblyDescriptor {
		i32 25600, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([25600 x i8], [25600 x i8]* @__CompressedAssemblyDescriptor_data_17, i32 0, i32 0); data
	}, 
	; 18
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([7168 x i8], [7168 x i8]* @__CompressedAssemblyDescriptor_data_18, i32 0, i32 0); data
	}, 
	; 19
	%struct.CompressedAssemblyDescriptor {
		i32 400896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([400896 x i8], [400896 x i8]* @__CompressedAssemblyDescriptor_data_19, i32 0, i32 0); data
	}, 
	; 20
	%struct.CompressedAssemblyDescriptor {
		i32 55808, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([55808 x i8], [55808 x i8]* @__CompressedAssemblyDescriptor_data_20, i32 0, i32 0); data
	}, 
	; 21
	%struct.CompressedAssemblyDescriptor {
		i32 919040, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([919040 x i8], [919040 x i8]* @__CompressedAssemblyDescriptor_data_21, i32 0, i32 0); data
	}, 
	; 22
	%struct.CompressedAssemblyDescriptor {
		i32 757248, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([757248 x i8], [757248 x i8]* @__CompressedAssemblyDescriptor_data_22, i32 0, i32 0); data
	}, 
	; 23
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14336 x i8], [14336 x i8]* @__CompressedAssemblyDescriptor_data_23, i32 0, i32 0); data
	}, 
	; 24
	%struct.CompressedAssemblyDescriptor {
		i32 14848, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14848 x i8], [14848 x i8]* @__CompressedAssemblyDescriptor_data_24, i32 0, i32 0); data
	}, 
	; 25
	%struct.CompressedAssemblyDescriptor {
		i32 8704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([8704 x i8], [8704 x i8]* @__CompressedAssemblyDescriptor_data_25, i32 0, i32 0); data
	}, 
	; 26
	%struct.CompressedAssemblyDescriptor {
		i32 428544, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([428544 x i8], [428544 x i8]* @__CompressedAssemblyDescriptor_data_26, i32 0, i32 0); data
	}, 
	; 27
	%struct.CompressedAssemblyDescriptor {
		i32 65024, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([65024 x i8], [65024 x i8]* @__CompressedAssemblyDescriptor_data_27, i32 0, i32 0); data
	}, 
	; 28
	%struct.CompressedAssemblyDescriptor {
		i32 15360, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15360 x i8], [15360 x i8]* @__CompressedAssemblyDescriptor_data_28, i32 0, i32 0); data
	}, 
	; 29
	%struct.CompressedAssemblyDescriptor {
		i32 135680, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([135680 x i8], [135680 x i8]* @__CompressedAssemblyDescriptor_data_29, i32 0, i32 0); data
	}, 
	; 30
	%struct.CompressedAssemblyDescriptor {
		i32 38912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([38912 x i8], [38912 x i8]* @__CompressedAssemblyDescriptor_data_30, i32 0, i32 0); data
	}, 
	; 31
	%struct.CompressedAssemblyDescriptor {
		i32 143360, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([143360 x i8], [143360 x i8]* @__CompressedAssemblyDescriptor_data_31, i32 0, i32 0); data
	}, 
	; 32
	%struct.CompressedAssemblyDescriptor {
		i32 34304, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([34304 x i8], [34304 x i8]* @__CompressedAssemblyDescriptor_data_32, i32 0, i32 0); data
	}, 
	; 33
	%struct.CompressedAssemblyDescriptor {
		i32 25088, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([25088 x i8], [25088 x i8]* @__CompressedAssemblyDescriptor_data_33, i32 0, i32 0); data
	}, 
	; 34
	%struct.CompressedAssemblyDescriptor {
		i32 52224, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([52224 x i8], [52224 x i8]* @__CompressedAssemblyDescriptor_data_34, i32 0, i32 0); data
	}, 
	; 35
	%struct.CompressedAssemblyDescriptor {
		i32 439808, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([439808 x i8], [439808 x i8]* @__CompressedAssemblyDescriptor_data_35, i32 0, i32 0); data
	}, 
	; 36
	%struct.CompressedAssemblyDescriptor {
		i32 15872, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15872 x i8], [15872 x i8]* @__CompressedAssemblyDescriptor_data_36, i32 0, i32 0); data
	}, 
	; 37
	%struct.CompressedAssemblyDescriptor {
		i32 379904, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([379904 x i8], [379904 x i8]* @__CompressedAssemblyDescriptor_data_37, i32 0, i32 0); data
	}, 
	; 38
	%struct.CompressedAssemblyDescriptor {
		i32 26624, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([26624 x i8], [26624 x i8]* @__CompressedAssemblyDescriptor_data_38, i32 0, i32 0); data
	}, 
	; 39
	%struct.CompressedAssemblyDescriptor {
		i32 1149952, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1149952 x i8], [1149952 x i8]* @__CompressedAssemblyDescriptor_data_39, i32 0, i32 0); data
	}, 
	; 40
	%struct.CompressedAssemblyDescriptor {
		i32 772096, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([772096 x i8], [772096 x i8]* @__CompressedAssemblyDescriptor_data_40, i32 0, i32 0); data
	}, 
	; 41
	%struct.CompressedAssemblyDescriptor {
		i32 128640, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([128640 x i8], [128640 x i8]* @__CompressedAssemblyDescriptor_data_41, i32 0, i32 0); data
	}, 
	; 42
	%struct.CompressedAssemblyDescriptor {
		i32 102912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([102912 x i8], [102912 x i8]* @__CompressedAssemblyDescriptor_data_42, i32 0, i32 0); data
	}, 
	; 43
	%struct.CompressedAssemblyDescriptor {
		i32 2063872, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2063872 x i8], [2063872 x i8]* @__CompressedAssemblyDescriptor_data_43, i32 0, i32 0); data
	}
], align 16; end of 'compressed_assembly_descriptors' array


; compressed_assemblies
@compressed_assemblies = local_unnamed_addr global %struct.CompressedAssemblies {
	i32 44, ; count
	%struct.CompressedAssemblyDescriptor* getelementptr inbounds ([44 x %struct.CompressedAssemblyDescriptor], [44 x %struct.CompressedAssemblyDescriptor]* @compressed_assembly_descriptors, i32 0, i32 0); descriptors
}, align 8


!llvm.module.flags = !{!0, !1}
!llvm.ident = !{!2}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{!"Xamarin.Android remotes/origin/d17-4 @ 13ba222766e8e41d419327749426023194660864"}
